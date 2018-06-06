import EmberRouter from '@ember/routing/router';
import config from './config/environment';

const Router = EmberRouter.extend({
  location: config.locationType,
  rootURL: config.rootURL
});

Router.map(function() {
  this.route('league');
  this.route('rules');
  this.route('news');
  this.route('schedule');
  this.route('standings');
  this.route('album');
  this.route('contact');
});

export default Router;
