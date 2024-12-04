import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ShellComponent } from './core/components/shell/shell.component';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { UsuarioTokenViewModel } from './core/auth/models/auth.models';
import { AuthService } from './core/auth/services/auth.service';
import { LocalStorageService } from './core/auth/services/local-storage.service';
import { UsuarioService } from './core/auth/services/usuario.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ShellComponent, AsyncPipe],
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  usuarioAutenticado$?: Observable<UsuarioTokenViewModel | undefined>;

  constructor(
    private router: Router,
    private authService: AuthService,
    private usuarioService: UsuarioService,
    private localStorageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    this.usuarioAutenticado$ = this.usuarioService.usuarioAutenticado;

    const token = this.localStorageService.obterTokenAutenticacao();

    if (!token) return;

    const usuarioPersistido = token.usuario;
    const dataExpiracaoToken = new Date(token.dataExpiracao);

    const tokenValido =
      this.authService.validarExpiracaoToken(dataExpiracaoToken);

    if (usuarioPersistido && tokenValido) {
      this.usuarioService.logarUsuario(usuarioPersistido);
    } else {
      this.efetuarLogout();
    }
  }
  efetuarLogout() {
    this.authService.logout();
    this.usuarioService.logout();
    this.localStorageService.limparDadosLocais();

    this.router.navigate(['/login']);
  }
}
