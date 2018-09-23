import Route from '@ember/routing/route';
import { inject as service } from '@ember/service';

export default Route.extend({
    imgur: service(),

    model() {
      return this.get('imgur').getAlbum()
        .then(x => x.data.map(y => {
          return {
            src: y.link,
            w: y.width,
            h: y.height,
            title: y.title,
            description: y.description
          };
        }));
    }
});