$(document).on('click', '.post-row', function () {
    let key = $(this).attr('data-key');
    window.location.href = "/forum/post?key=" + key;
});
