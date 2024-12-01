import { Routes } from '@angular/router';
import { ListagemAtividadesComponent } from './listar/listagem-atividades.component';

export const AtividadesRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemAtividadesComponent },
];
