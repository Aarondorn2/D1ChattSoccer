import EmberRouter from '@ember/routing/router';
import config from './config/environment';

const Router = EmberRouter.extend({
  location: config.locationType,
  rootURL: config.rootURL
});

Router.map(function() {
  // legacy links
  this.route('league', function() {
    this.route('schedule');
    this.route('standings');
  });

  this.route('about');
  this.route('album');
  this.route('contact');
  this.route('rules');
  this.route('schedule');
  this.route('standings');
});

export default Router;
