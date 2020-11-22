// https://docs.cypress.io/api/introduction/api.html

describe('About.vue', () => {
  it('Displays text on page', () => {
    cy.visit('/about');
    cy.contains('h1', 'This is an about page');
  });
});
