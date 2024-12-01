import { ActivatedRouteSnapshot, ResolveFn, Routes } from '@angular/router';
import { ListagemAtividadesComponent } from './listar/listagem-atividades.component';
import { CadastroAtividadesComponent } from './cadastrar/cadastro-atividades.component';
import { MedicoService } from '../medicos/services/medico.service';
import { inject } from '@angular/core';
import { ListarMedicoViewModel } from '../medicos/models/medico.models';
import { ExclusaoAtividadesComponent } from './excluir/exclusao-atividades.component';
import { VisualizarAtividadeViewModel } from './models/atividade.models';
import { AtividadeService } from './services/atividades.service';

const visualizarAtividadesResolver: ResolveFn<VisualizarAtividadeViewModel> = (
  route: ActivatedRouteSnapshot
) => {
  const id = route.params['id'];
  return inject(AtividadeService).selecionarPorId(id);
};

const ListagemMedicosResolver: ResolveFn<ListarMedicoViewModel[]> = () => {
  return inject(MedicoService).selecionarTodos();
};

export const AtividadesRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemAtividadesComponent },
  {
    path: 'cadastrar',
    component: CadastroAtividadesComponent,
    resolve: {
      medicos: ListagemMedicosResolver,
    },
  },
  {
    path: 'excluir/:id',
    component: ExclusaoAtividadesComponent,
    resolve: { atividade: visualizarAtividadesResolver },
  },
];
