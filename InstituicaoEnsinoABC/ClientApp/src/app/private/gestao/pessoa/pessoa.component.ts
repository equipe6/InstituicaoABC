import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { PessoaDataService } from '../../../_data-services/pessoa.data-service';
import { AlunoDataService } from 'src/app/_data-services/aluno.data-service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
})

export class PessoaComponent {

  faHome = faHome;
  faArrowLeft = faArrowLeft;

  sistema: string = 'gestao';
  modulo: string = 'pessoas';
  titulo: string = 'Pessoas';

  usuarioLogado: any = {};
  alunos: any = [];


  pessoa_id: any = 0;
  acao: any = '';
  pessoa: any = {};

  isDisabled: any = false;
  resenha: any = '';
  pwdRequired: any = false;

  constructor(
    private store: StoreService,
    private pessoaDataService: PessoaDataService,
    private alunosDataService: AlunoDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.pessoaDataService = pessoaDataService;
    this.alunosDataService = alunosDataService;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.pessoa_id = p.id;
      this.acao = (p.acao ? p.acao : 'cadastrar');

      if (this.pessoa_id) {
        this.getById(this.pessoa_id);
      }

      if (this.acao == 'detalhes' || this.acao == 'remover') {
        this.isDisabled = true;
      }
      if (this.acao == 'cadastrar') {
        this.pwdRequired = true;
      }
    })
  }


  getById(pessoa_id) {
    this.pessoaDataService.getById(pessoa_id).subscribe((data:any[]) => {
      
      console.log(data);
      this.pessoa = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  onSubmit() {
    if (this.pessoa.nomeCompleto === undefined || this.pessoa.nomeCompleto === '' || this.pessoa.nomeCompleto === null) {
      document.getElementById('nome_completo_aluno').focus();
      return;
    }
    if (this.pessoa.cpf === undefined || this.pessoa.cpf === '' || this.pessoa.cpf === null) {
      document.getElementById('inputCpf').focus();
      return;
    }
    if (this.acao == 'cadastrar') {
      this.cadastrarpessoa();
    } else if (this.acao == 'editar') {
      this.editarpessoa();
    } else if (this.acao == 'remover') {
      this.removerpessoa(this.pessoa_id);
    }
  }

  cadastrarpessoa() {
    this.pessoaDataService.post(this.pessoa).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['pessoas']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  editarpessoa() {
    this.pessoaDataService.put(this.pessoa).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['pessoas']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  removerpessoa(pessoa_id) {
    this.pessoaDataService.delete(pessoa_id).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['pessoas']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }
}
