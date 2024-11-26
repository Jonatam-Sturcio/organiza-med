import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { NgForOf } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ItemDashboard } from './models/item-dashboard.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    RouterLink,
    NgForOf,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
  itens: ItemDashboard[] = [
    {
      titulo: 'Medicos',
      descricao: 'Gerencie as categorias utilizadas para organizar as notas.',
      rota: '/medicos',
      icone: 'groups',
    },
    {
      titulo: 'Atividades',
      descricao:
        'Gerencie as suas tarefas do dia-a-dia com notas que você pode organizar.',
      rota: '/atividades',
      icone: 'medical_services',
    },
  ];
}
