import Route from '@ember/routing/route';
import { inject as service } from '@ember/service';

export default Route.extend({
    imgur: service(),

    model() {
      return this.imgur.getAlbum('oKmurVW')
        .then(x => x.data.map(y => {
          return {
            src: y.link,
            w: y.width,
            h: y.height
          };
        }));
    }
});