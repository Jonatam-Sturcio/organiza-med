import { NgIf, NgForOf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterLink } from '@angular/router';
import { map, Observable, tap } from 'rxjs';
import { ListarMedicoViewModel } from '../models/medico.models';
import { MedicoService } from '../services/medico.service';

@Component({
  selector: 'app-listagem-medicos',
  standalone: true,
  imports: [
    NgIf,
    NgForOf,
    RouterLink,
    AsyncPipe,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
  ],
  templateUrl: './listagem-medicos.component.html',
  styleUrl: './listagem-medicos.component.scss',
})
export class ListagemMedicosComponent implements OnInit {
  medicos$?: Observable<any>;

  constructor(private medicoService: MedicoService) {}

  ngOnInit(): void {
    this.medicos$ = this.medicoService.selecionarTodos();
  }
}
