// https://docs.cypress.io/api/introduction/api.html

describe('Players.vue', () => {
  it('Displays text on page', () => {
    cy.visit('/players');
    cy.contains('h1', 'The Players');
  });

  it('Displays list of players', () => {
    cy.visit('/players');
    // wait for 2nd row to appear first before evaluating
    cy.get('#players-table > :nth-child(2) > :nth-child(1)', { timeout: 10000 }).should('be.visible');
    // now evaluate the rows count
    cy.get('#players-table').find('tr').should((elements) => {
      expect(elements).to.have.length(4);
    });
  });
});
