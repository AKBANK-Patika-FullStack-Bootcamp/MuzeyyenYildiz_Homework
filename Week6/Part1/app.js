const {gofret} = require('./kopek');
const {kopegiTemizle, kopekBakimSaati} = require('./kopekBakimUtility');


console.log(`Kopek adi: ${gofret.name}
kopek boyu: ${gofret.long}`);

kopegiTemizle();

console.log(`Kopek ilgi saati: ${kopekBakimSaati}`)