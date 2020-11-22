// https://docs.cypress.io/api/introduction/api.html

describe('Home.vue', () => {
  it('Visits the app root url', () => {
    cy.visit('/');
    cy.contains('h1', 'Welcome to Your Vue.js App');
  });

  it('Displays the About Link', () => {
    cy.visit('/');
    cy.contains('a', 'About');
  });

  it('Displays the Home Link', () => {
    cy.visit('/');
    cy.contains('a', 'Home');
  });

  it('Displays the Players Link', () => {
    cy.visit('/');
    cy.contains('a', 'Players');
  });
});
