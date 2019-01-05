import Object from '@ember/object';

export default Object.extend({
  open(options) {
    return new Promise((resolve) => resolve({ provider: 'email', email: options.email, password: options.pass }));
  }
})
