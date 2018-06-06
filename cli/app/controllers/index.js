import Controller from '@ember/controller';
// import { inject as service } from '@ember/service';
import $ from 'jquery';

export default Controller.extend({
  // session: service(),

  init() {
    this._super(...arguments);

    //fade out subheader
    $(window).scroll(() => {

      let scrollTop = $(window).scrollTop();
      // console.log(scrollTop);
      if(scrollTop >= 200) {
        $(".subheader h2").hide();
      } else {
        $(".subheader h2").show();

        if(scrollTop >= 100) {
          let op = 1 - ((scrollTop - 100) / 100);
          $(".subheader h2").css("opacity", op );
        } else {
          $(".subheader h2").css("opacity", 1 );
        }
      }

    });
  },
  actions: {
    // showLoginModal: function() {
    //   if(this.session.isAuthenticated) {
    //     this.transitionToRoute('secure.dashboard');
    //   } else {
    //     $('#login-modal').modal('show');
    //   }
    // }
  }
});
