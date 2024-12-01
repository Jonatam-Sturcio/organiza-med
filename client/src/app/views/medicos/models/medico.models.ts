import { ListarAtividadeViewModel } from '../../atividades/models/atividade.models';

export interface InserirMedicoViewModel {
  nome: string;
  especialidade: string;
  CRM: string;
}

export interface MedicoInseridoViewModel {
  id: string;
  nome: string;
  especialidade: string;
  CRM: string;
}

export interface EdicaoMedicoViewModel {
  nome: string;
  especialidade: string;
  CRM: string;
}

export interface MedicoEditadoViewModel {
  id: string;
  nome: string;
  especialidade: string;
  CRM: string;
}

export interface VisualizarMedicoViewModel {
  id: string;
  nome: string;
  especialidade: string;
  CRM: string;
  Atividades: ListarAtividadeViewModel[];
}

export interface ListarMedicoViewModel {
  id: string;
  nome: string;
  especialidade: string;
  crm: string;
}

export interface MedicoExcluidoViewModel {}
