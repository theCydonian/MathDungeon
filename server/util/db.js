let admin = require('firebase-admin');

let serviceKey = require('./firebase-serivce-key.json');
let databaseURL = require('./firebase-url.json');

admin.initializeApp({
    credential: admin.credential.cert(serviceKey),
    databaseURL: databaseURL,
});

let db = admin.firestore();

module.exports.readCollection = function readCollectionFromDB(path) {
    return db.collection(path).get();
}

module.exports.readDoc = function readDocumentFromDB(path) {
    return db.doc(path).get();
}

module.exports.addDoc = function readDocumentFromDB(path, data) {
    return db.collection(path).add(data);
}