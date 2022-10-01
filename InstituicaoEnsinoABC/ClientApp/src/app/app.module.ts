import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { UsuarioDataService } from './_data-services/usuario.data-service';
import { AlunoDataService } from './_data-services/aluno.data-service';
// import { VacinaDataService } from './_data-services/vacina.data-service';
// import { MedicamentoDataService } from './_data-services/medicamento.data-service';
// import { AnamneseDataService } from './_data-services/anamnese.data-service';
import { ContratoDataService } from './_data-services/contrato.data-service';
import { PagamentoDataService } from './_data-services/pagamento.data-service';

import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DataTablesModule } from 'angular-datatables';

import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';

import { LoginComponent } from './public/login/login.component';
import { HomeComponent } from './private/home/home.component';

import { UsuariosComponent } from './private/gestao/usuarios/usuarios.component';
import { UsuarioComponent } from './private/gestao/usuario/usuario.component';
import { PessoasComponent } from './private/gestao/pessoas/pessoas.component';
import { PessoaComponent } from './private/gestao/pessoa/pessoa.component';
import { AlunosComponent } from './private/gestao/alunos/alunos.component';
import { AlunoComponent } from './private/gestao/aluno/aluno.component';

import { ContratosComponent } from './private/financeiro/contratos/contratos.component';
import { ParcelasComponent } from './private/financeiro/parcelas/parcelas.component';
import { PagamentoComponent } from './private/financeiro/pagamento/pagamento.component';
import { PessoaDataService } from './_data-services/pessoa.data-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavBarComponent,
    FooterComponent,
    PageNotFoundComponent,

    LoginComponent,
    HomeComponent,

    UsuariosComponent,
      UsuarioComponent,
    AlunosComponent,
      AlunoComponent,
    PessoasComponent,
      PessoaComponent,

    ContratosComponent,
    ParcelasComponent,
    PagamentoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    DataTablesModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    UsuarioDataService,
    AlunoDataService,
    PessoaDataService,
    ContratoDataService,
    PagamentoDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
