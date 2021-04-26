$(function () {

    function DisplayResult1(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, (i, item) => {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };
    //change the below port num. The below url is the LibraryService url
    var serviceUrl = 'https://localhost:44357/api';

    $('#GetAll').on('click', () => {

        $.ajax(serviceUrl + '/books')
            .done((data) => {
                DisplayResult1("Get All:", data);
                console.log(data);
            }).fail((error) => {
                console.log('error');
            }).always(() => {
                console.log('Inside always method');
            });
    });

    $('#GetById').on('click', () => {
        var bookId = $('#Id').val();

        $.ajax(serviceUrl + '/books/' + bookId)
            .done((data) => {
                DisplayResult2("Book by id:", data);
                console.log(data);
            }).fail((error) => {
                console.log('error');
            }).always(() => {
                console.log('Inside always method');
            });
    });

    //using promise
    $('#AddBook').on('click', () => {
        var inputData = $('input').serialize();
        $.ajax({
            url: serviceUrl + '/books/PostBook',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: inputData
        }).done((data) => {
            try {
                DisplayResult2("Add Book", data);
                console.log(data);
            } catch (err) {
                console.log(err);
            }
        }).fail((error) => {
            console.log(error);

        }).always(() => {
            console.log('I will be execute no matter what');
        });
    });

    //using callback
    $('#UpdateBook').on('click', function () {
        var inputData = $('input').serialize();
        var bookId = $('#Id').val();
        $.ajax({
            url: serviceUrl + '/books/Update',
            method: 'PUT',
            contentType: 'application/x-www-form-urlencoded',
            data: inputData,
            success: function (data) {
                DisplayResult1("Updated list:", data);
            }
        });
    });

    //using callback
    $('#DeleteBook').on('click', function () {
        var bookId = $('#Id').val();

        $.ajax({

            url: serviceUrl + "/books/" + bookId,
            type: 'DELETE'

        })
            .done((data) => {
                console.log(data);
            }).fail((error) => {
                console.log('error');
            }).always(() => {
                console.log('Inside always method');
            });
    });
});