describe('Processo de redirecionamento para modulo Atividade', () => {
  beforeEach(() => {
    cy.visit('/');

    cy.contains('Dashboard');

    cy.wait(500);

    cy.get('[data-cy=atividades]').click();
  });

  it('Deve navegar até Atividades', () => {
    cy.contains('Listagem de Atividades');
  });

  it('Deve cadastrar uma nova atividade', () => {
    cy.get('[data-cy=cadastrar]').click();

    cy.get('[data-cy=horaInicio]').type('08:00');
    cy.get('[data-cy=horaTermino]').type('10:00');

    cy.get('[data-cy=medicosId]').click();
    cy.get('[data-cy-select-option]').last().click();
    cy.get('body').click();

    cy.get('[data-cy=confirmar]').click();

    cy.wait(1000);

    cy.contains('Hora de Inicio: 08:00');
  });

  it('Deve editar uma Atividade', () => {
    cy.get('[data-cy=editar]').last().click();

    cy.wait(1000);

    cy.get('[data-cy=horaTermino]').clear().type('10:30');

    cy.get('[data-cy=confirmar]').click();

    cy.wait(1000);

    cy.contains('Hora de Termino: 10:30');
  });

  it('Deve excluir um medico', () => {
    cy.get('[data-cy=excluir]').last().click();

    cy.get('[data-cy=confirmar]').click();

    cy.contains('Hora de Inicio: 10:30').should('not.exist');
  });
});
