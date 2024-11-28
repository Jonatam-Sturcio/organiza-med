describe('Processo de redirecionamento para modulo Medicos', () => {
  beforeEach(() => {
    cy.visit('/');

    cy.contains('Dashboard');

    cy.wait(500);

    cy.get('[data-cy=medicos]').click();
  });

  it('Deve navegar até Médicos', () => {
    cy.contains('Listagem de Médicos');
  });

  it('Deve cadastrar um novo médico', () => {
    cy.get('[data-cy=cadastrar]').click();

    cy.get('[data-cy=nome]').type('Nome Cypress');
    cy.get('[data-cy=crm]').type('98574-CY');
    cy.get('[data-cy=especialidade]').type('Especialidade Cypress');

    cy.get('[data-cy=confirmar]').click();

    cy.wait(1000);

    cy.contains('Nome Cypress');
  });

  it('Deve editar um medico', () => {
    cy.get('[data-cy=editar]').last().click();

    cy.wait(1000);

    cy.get('[data-cy=nome]').clear().type('Nome Cypress Editado');

    cy.get('[data-cy=confirmar]').click();

    cy.wait(1000);

    cy.contains('Nome Cypress Editado');
  });

  it('Deve excluir uma categoria', () => {
    cy.get('[data-cy=excluir]').last().click();

    cy.get('[data-cy=confirmar]').click();

    cy.contains('Nome Cypress Editado').should('not.exist');
  });
});
