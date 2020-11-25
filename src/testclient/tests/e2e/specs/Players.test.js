// https://docs.cypress.io/api/introduction/api.html

describe('Players.vue', () => {
  it('Displays text on page', () => {
    cy.visit('/players');
    cy.contains('h1', 'The Players');
  });

  it('Displays list of players', () => {
    cy.visit('/players');
    cy.get('#players-table').find('tr').should((elements) => {
      expect(elements).to.have.length(4);
    });
  });
});
