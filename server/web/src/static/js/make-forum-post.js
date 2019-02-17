$(document).on('click', '#post-button', function () {
    let poster = $('#post-poster-field').val();
    let title = $('#post-title-field').val();
    let body = $('#post-body-field').val();
    let key = new URL(window.location.href).searchParams.get('key');
    $.ajax({
        url: '/api/make-forum-post',
        type: 'POST',
        data: JSON.stringify({
            title, 
            body, 
            poster,
        }), 
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
    }).done((data) => {
        window.location.href = '/forum';
    }).fail((error) => {
        window.location.href = '/forum';
    });
});