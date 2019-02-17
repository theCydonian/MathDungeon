let path = require('path');
let express = require('express');
let bodyParser = require('body-parser');
let app = express();
let fs = require('fs');
let templates = require('./util/templates.js');
let db = require('./util/db.js');

let forumTemplate = templates.get('./web/src/static/templates/forum.hbs');
let forumPostTemplate = templates.get('./web/src/static/templates/forum-post.hbs');
let lessonTemplate = templates.get('./web/src/static/templates/lesson.hbs');
let gameTemplate = templates.get('./web/src/static/templates/game.hbs');

app.use(bodyParser.json());

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, './web/src/static/templates/index.html'));
});

app.get('/lesson/:lesson', (req, res) => {
    let lesson = req.params.lesson;

    let lessonHTML = fs.readFileSync(
        path.join(__dirname, './web/src/static/templates/lessons/' + lesson + '.html'),
        'utf-8',
    );
    
    res.send(lessonTemplate({ lessonHTML }));
});


app.get('/game/:name', (req, res) => {
    let name = req.params.name;
    
    res.send(gameTemplate({ gameName: name }));
});

app.get('/forum', (req, res) => {
    db.readCollection('forumPosts').then((snapshot) => {
        let forumPosts = {};

        snapshot.forEach((doc) => {
            forumPosts[doc.id] = doc.data();
        });

        res.send(forumTemplate({ forumPosts }));
    });
});

app.get('/make-forum-post', (req, res) => {
    res.sendFile(path.join(__dirname, './web/src/static/templates/make-forum-post.html'));
});

app.get('/forum/post', (req, res) => {
    db.readDoc('forumPosts/' + req.query.key).then((postSnapshot) => {
        db.readCollection('forumPosts/' + req.query.key + '/comments').then((commentsSnapshot) => {
            let comments = {};

            commentsSnapshot.forEach((doc) => {
                comments[doc.id] = doc.data();
            });

            res.send(forumPostTemplate({...postSnapshot.data(), comments}));
        })
    });
});

app.post('/api/make-forum-post', (req, res) => {
    let title = req.body.title;
    let body = req.body.body;
    let poster = req.body.poster;

    db.addDoc('forumPosts', { 
        title, 
        body,
        poster, 
        date: (new Date()).toDateString(),
    }).then((ref) => {
        res.send(ref.id);
    });
});

app.post('/api/make-forum-comment', (req, res) => {
    let key = req.body.key;
    let body = req.body.body;
    let commenter = req.body.commenter;

    db.addDoc('forumPosts/' + key + '/comments', { 
        body, 
        commenter, 
        date: (new Date()).toDateString(),
    }).then((ref) => {
        res.send(ref.id);
    });
});

app.use('/static/js', express.static('web/src/static/js/'));
app.use('/static/webgl-build', express.static('web/src/static/webgl-build/'));
app.use('/static/style', express.static('web/dist/static/style/'));

let port = process.env.PORT || 8080;

app.listen(port, (error) => {
    if (error) {
        console.log(error);
        return;
    }

    console.log('Listening on port ' + port);
});
