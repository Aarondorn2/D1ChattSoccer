'use strict';

module.exports = function(environment) {
  let ENV = {
    modulePrefix: 'D1ChattSoccer',
    environment,
    rootURL: '/',
    locationType: 'auto',

    googleMap: {
      apiKey: 'AIzaSyC1Qw5PPqCtX4RDpR_421YbemowNju73u0'
    },
    
    torii: {
      sessionServiceName: 'session',
      providers: {
        'facebook-connect': {
          appId: '1946494598986774',
          scope: 'email'
        },
        'google-oauth2': {
          apiKey: '647564758213-ht32t2ma1rvn0apgi8qhe4124cnpg1rq.apps.googleusercontent.com',
          redirectUri: 'http://localhost:4200/torii/redirect.html',
          scope: 'email'
        }
      }
    },

    contentSecurityPolicy: {
      'default-src': "'none'",
      'script-src': "'self' 'unsafe-eval' *.googleapis.com maps.gstatic.com",
      'font-src': "'self' fonts.gstatic.com",
      'connect-src': "'self' maps.gstatic.com",
      'img-src': "'self' *.googleapis.com maps.gstatic.com csi.gstatic.com",
      'style-src': "'self' 'unsafe-inline' fonts.googleapis.com maps.gstatic.com"
    },

    EmberENV: {
      FEATURES: {
        // Here you can enable experimental features on an ember canary build
        // e.g. 'with-controller': true
      },
      EXTEND_PROTOTYPES: {
        // Prevent Ember Data from overriding Date.parse.
        Date: false
      }
    },

    APP: {
      // Here you can pass flags/options to your application instance
      // when it is created
    }
  };

  if (environment === 'development') {
    // ENV.APP.LOG_RESOLVER = true;
    // ENV.APP.LOG_ACTIVE_GENERATION = true;
    // ENV.APP.LOG_TRANSITIONS = true;
    // ENV.APP.LOG_TRANSITIONS_INTERNAL = true;
    // ENV.APP.LOG_VIEW_LOOKUPS = true;
    ENV.API = {
      host: 'http://localhost:53304',
      namespace: '/api'
    };
  }

  if (environment === 'test') {
    // Testem prefers this...
    ENV.locationType = 'none';

    // keep test console output quieter
    ENV.APP.LOG_ACTIVE_GENERATION = false;
    ENV.APP.LOG_VIEW_LOOKUPS = false;

    ENV.APP.rootElement = '#ember-testing';
    ENV.APP.autoboot = false;
  }

  if (environment === 'production') {
    // here you can enable a production-specific feature
  }

  return ENV;
};
