module.exports = {
  root: true,
  parserOptions: {
    ecmaVersion: 2017,
    sourceType: 'module'
  },
  plugins: [
    'ember'
  ],
  extends: [
    'eslint:recommended',
    'plugin:ember/recommended'
  ],
  env: {
    browser: true
  },
  rules: {
    'arrow-parens': 0,
    'ember/no-attrs-in-components': 0,
    'ember/no-capital-letters-in-routes': 0,
    'ember/routes-segments-snake-case': 0,
    'new-cap': 0,
    'no-console': ['error', { allow: ['warn', 'error'] }],
    'no-var': 'error'
  },
  overrides: [
    // node files
    {
      files: [
        'ember-cli-build.js',
        'testem.js',
        'blueprints/*/index.js',
        'config/**/*.js',
        'lib/*/index.js'
      ],
      parserOptions: {
        sourceType: 'script',
        ecmaVersion: 2015
      },
      env: {
        browser: false,
        node: true
      }
    }
  ]
};
