import { NgIf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink, ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';
import { VisualizarMedicoViewModel } from '../models/medico.models';
import { MedicoService } from '../services/medico.service';

@Component({
  selector: 'app-exclusao-medico',
  standalone: true,
  imports: [NgIf, RouterLink, AsyncPipe, MatButtonModule, MatIconModule],
  templateUrl: './exclusao-medico.component.html',
  styleUrl: './exclusao-medico.component.scss',
})
export class ExclusaoMedicoComponent implements OnInit {
  id?: string;
  Medico$?: Observable<VisualizarMedicoViewModel>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private MedicoService: MedicoService,
    private notificacao: NotificacaoService
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    this.Medico$ = this.MedicoService.selecionarPorId(this.id);
  }

  excluir() {
    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    this.MedicoService.excluir(this.id).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${this.id}] foi excluído com sucesso!`
      );

      this.router.navigate(['/medicos']);
    });
  }
}
