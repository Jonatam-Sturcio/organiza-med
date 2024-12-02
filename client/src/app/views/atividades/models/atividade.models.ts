import {
  ListarMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../../medicos/models/medico.models';
import { tipoAtividadeEnum } from './tipoAtividadeEnum';

export interface InserirAtividadeViewModel {
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicosId: number[];
}

export interface AtividadeInseridaViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicosId: number[];
}

export interface EdicaoAtividadeViewModel {
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicosId: number[];
}

export interface AtividadeEditadaViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicosId: number[];
}

export interface VisualizarAtividadeViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicos: ListarMedicoViewModel[];
}

export interface ListarAtividadeViewModel {
  id: string;
  horaInicio: Date;
  horaTermino: Date;
  tipoAtividade: tipoAtividadeEnum;
  medicos: ListarMedicoViewModel[];
}

export interface AtividadeExcluidaViewModel {}
