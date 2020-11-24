module.exports = {
  plugins: [
    'cypress',
  ],
  env: {
    mocha: true,
    'cypress/globals': true,
  },
  rules: {
    strict: 'off',
    "linebreak-style": 0,
    "arrow-body-style": 0
  },
};
