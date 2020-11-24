// https://docs.cypress.io/api/introduction/api.html

describe('Players.vue', () => {
  it('Displays text on page', () => {
    cy.visit('/players');
    cy.contains('h2', 'Players');
  });
});
