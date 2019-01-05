import Route from '@ember/routing/route';

export default Route.extend({
  beforeModel() {
    // Try to restore session from local storage. If no session, do nothing.
    return this.get('session').fetch()
      .catch(() => {});
  }
});
