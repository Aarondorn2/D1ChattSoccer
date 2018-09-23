import Component from '@ember/component';
import $ from 'jquery';

export default Component.extend({
  willRender() {
    switch(this.get('theme')) {
      case "dark":
        $('html').addClass('dark-bg').removeClass('main-bg'); //change background
        break;
      default:
        $('html').addClass('page-bg').removeClass('main-bg'); //change background
        break;
    }
  },

  willClearRender() {
      $('html').addClass('main-bg') //change background back to main
      .removeClass('page-bg') //remove other backgrounds
      .removeClass('dark-bg');
  }
});
