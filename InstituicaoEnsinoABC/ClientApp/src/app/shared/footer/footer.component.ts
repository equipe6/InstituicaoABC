import { Component, Input } from '@angular/core';
import { StoreService } from '../../store.service';
import { Router } from '@angular/router';
import { faHome } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent {

  faHome = faHome;

  usuarioLogado: any = {};

  @Input() sistema = '';
  @Input() modulo = '';

  dtHoje: string = this.dataAtualFormatada();


  

  constructor(
    private store: StoreService,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;
  }

  ngOnInit() {

  }

  dataAtualFormatada(){
    var data = new Date(),
        dia  = data.getDate().toString(),
        diaF = (dia.length == 1) ? '0'+dia : dia,
        mes  = (data.getMonth()+1).toString(), //+1 pois no getMonth Janeiro começa com zero.
        mesF = (mes.length == 1) ? '0'+mes : mes,
        anoF = data.getFullYear();
    return diaF+"/"+mesF+"/"+anoF;
}

}
