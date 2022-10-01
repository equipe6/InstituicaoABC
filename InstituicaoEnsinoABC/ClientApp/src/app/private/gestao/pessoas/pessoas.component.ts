import { Component } from '@angular/core';
import { StoreService } from '../../../store.service';
import { faHome, faPlus, faSearch, faPencilAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { PessoaDataService } from '../../../_data-services/pessoa.data-service';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
})
export class PessoasComponent {

  faHome = faHome;
  faPlus = faPlus;
  faSearch = faSearch;
  faPencilAlt = faPencilAlt;
  faTrash = faTrash;

  sistema: string = 'gestao';
  modulo: string = 'Pessoas';
  titulo: string = 'Pessoas';

  usuarioLogado: any = {};

  pessoas: any = [];

  constructor(
    private store: StoreService,
    private pessoaDataService: PessoaDataService
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.pessoaDataService = pessoaDataService;
  }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.pessoaDataService.getAll().subscribe((data:any[]) => {
      this.pessoas = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }
}
