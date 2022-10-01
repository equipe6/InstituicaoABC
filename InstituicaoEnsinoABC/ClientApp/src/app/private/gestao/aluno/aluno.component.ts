import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { AlunoDataService } from '../../../_data-services/aluno.data-service';
import { PessoaDataService } from 'src/app/_data-services/pessoa.data-service';
import { FUNCTION_TYPE } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
})
export class AlunoComponent {

  faHome = faHome;
  faArrowLeft = faArrowLeft;

  sistema: string = 'gestao';
  modulo: string = 'alunos';
  titulo: string = 'Aluno';

  usuarioLogado: any = {};

  aluno_id: any = 0;
  acao: any = '';
  idAluno = 0;
  aluno: any = {};
  pessoas: any = [];
  isDisabled: any = false;
  arquivo: any={};
  arquivo64: any = '';
  documento: any= {};
  documentos: any = [];

  constructor(
    private store: StoreService,
    private alunoDataService: AlunoDataService,
    private pessoaDataService: PessoaDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.alunoDataService = alunoDataService;
    this.pessoaDataService = pessoaDataService;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.aluno_id = p.id;
      this.acao = (p.acao ? p.acao : 'cadastrar aluno');

      if (this.aluno_id) {
        this.getById(this.aluno_id);
      }

      if (this.acao == 'detalhes' || this.acao == 'remover') {
        this.isDisabled = true;
      }
      this.getAllPeople();
    })
  }

  getAllPeople(){
    this.pessoaDataService.getAll().subscribe((data:any[]) => {
      this.pessoas = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  getById(aluno_id) {
    this.alunoDataService.getById(aluno_id).subscribe((data:any[]) => {
      console.log(data);
      this.aluno = data;
      this.documentos = this.aluno.documentos;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  onSubmit() {
    debugger
    if (this.aluno.matricula === undefined || this.aluno.matricula === '' || this.aluno.matricula === null) {
      document.getElementById('inputMatricula').focus();
      return;
    }
    if (this.aluno.idPessoa === undefined ||this.aluno.idPessoa=== null) {
      document.getElementById('inputAluno').focus();
      return;
    }
    if (this.acao == 'cadastrar aluno') {
      this.cadastrarAluno();
    } else if (this.acao == 'editar') {
      this.editarAluno();
    } else if (this.acao == 'remover') {
      this.removerAluno(this.aluno_id);
    }
  }

  cadastrarAluno() {
    this.alunoDataService.post(this.aluno).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  editarAluno() {
    this.alunoDataService.put(this.aluno).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  removerAluno(aluno_id) {
    this.alunoDataService.delete(aluno_id).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }
  onPessoaSelected(){
    const retorno = this.pessoas.find(a => {
        var b = a.idPessoa == this.aluno.pessoa_id ? a.idPessoa : "";
        console.log(b)
        return b
        
    });
    this.aluno.idPessoa  = retorno.idPessoa;
  }

  loadArquivo(event){
    if(event.target.files && event.target.files[0]){
      this.arquivo = event.target.files[0];

      let reader = new FileReader();
    
      reader.readAsDataURL(this.arquivo);
      reader.onloadend = () => {
        this.arquivo64 = reader.result;
        console.log(this.arquivo64)
      }
    }
  }

  loadDocumentoInfo(){
      console.log(this.arquivo);
      this.documento.arquivo = this.arquivo64
      this.documento.mimeType = this.arquivo.type;
      this.documento.nomeDocumento = this.arquivo.name;
      this.documentos.push(this.documento);
      this.aluno.documentos = this.documentos;
      this.documento = {}
  }

  olhaDocumento(idDocumento){

  }

  deletarDocumento(idDocumento){

  }
}


