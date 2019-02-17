$(document).on('click', '#comment-button', function () {
    let commenter = $('#comment-commenter-field').val();
    let body = $('#comment-body-field').val();
    let key = new URL(window.location.href).searchParams.get('key');
    $.ajax({
        url: '/api/make-forum-comment',
        type: 'POST',
        data: JSON.stringify({
            key, 
            body, 
            commenter,
        }), 
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
    }).done((data) => {
        $('#comment-commenter-field').val('');
        $('#comment-body-field').val('');
        location.reload();
    }).fail((error) => {
        $('#comment-commenter-field').val('');
        $('#comment-body-field').val('');
        location.reload();
    });
});