import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import {
  ListarMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../models/medico.models';
import { DatePipe, NgForOf } from '@angular/common';
import { tipoAtividadeEnum } from '../../atividades/models/tipoAtividadeEnum';

@Component({
  selector: 'app-detalhes-medico',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
  ],
  templateUrl: './detalhes-medico.component.html',
})
export class DetalhesMedicoComponent implements OnInit {
  Medico?: VisualizarMedicoViewModel;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.Medico = this.route.snapshot.data['medico'];
  }

  public obterTextoTipoAtividade(prioridade: tipoAtividadeEnum): string {
    return tipoAtividadeEnum[Number(prioridade)];
  }
  public formatarData(data: Date): string | null {
    var date = new Date(data);
    var [ano, mes, dia] = date.toISOString().split('T')[0].split('-');
    return `${dia}/${mes}/${ano}`;
  }
}
