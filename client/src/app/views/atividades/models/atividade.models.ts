import { VisualizarMedicoViewModel } from '../../medicos/models/medico.models';
import { tipoAtividade } from './tipoAtividadeEnum';

export interface InserirAtividadeViewModel {
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface AtividadeInseridaViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface EdicaoAtividadeViewModel {
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface AtividadeEditadaViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface VisualizarAtividadeViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface ListarAtividadeViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividade;
  medicos: VisualizarMedicoViewModel[];
}

export interface AtividadeExcluidaViewModel {}
