import { NgIf, AsyncPipe, NgForOf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink, ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';
import {
  ListarMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../models/medico.models';
import { MedicoService } from '../services/medico.service';
import { MatCardModule } from '@angular/material/card';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-exclusao-medico',
  standalone: true,
  imports: [
    RouterLink,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
  ],
  templateUrl: './exclusao-medico.component.html',
})
export class ExclusaoMedicoComponent implements OnInit {
  Medico?: ListarMedicoViewModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private MedicoService: MedicoService,
    private notificacao: NotificacaoService
  ) {}

  ngOnInit(): void {
    this.Medico = this.route.snapshot.data['medico'];
  }

  excluir() {
    if (!this.Medico?.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    this.MedicoService.excluir(this.Medico?.id).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${this.Medico?.id}] foi excluído com sucesso!`
      );

      this.router.navigate(['/medicos']);
    });
  }
}
