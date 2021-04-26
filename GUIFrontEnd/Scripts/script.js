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
                debugger;
                DisplayResult1("Get All:", data);
                console.log(data);
            }).fail((error) => {
                console.log('error');
            }).always(() => {
                console.log('Inside always method');
            });
    });

    $('#GetById').on('click', () => {
        var bookId = $('#id').val();

        $.ajax(serviceUrl + '/books/ ' + bookId)
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
            url: serviceUrl + '/books/',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(inputData)
        }).done((data) => {
            DisplayResult2("Add Book", data);
            console.log(data);

        }).fail((error) => {
            console.log(error);

        }).always(() => {
            console.log('I will be execute no matter what');
        });
    });

    //using callback
    $('#UpdateBook').on('click', function () {
        var inputData = $('input').serialize();
        var bookId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/books/' + bookId,
            method: 'PUT',
            data: inputData,
            success: function (data) {
                DisplayResult1("Updated list:", data);
            }
        });
    });

    //using callback
    $('#AddCost').on('click', function () {
        var inputData = $('input').serialize();
        var bookId = $('#BookId').val();
        //alert(bookId);
        $.ajax({
            url: serviceUrl + '/books/updatecost/' + bookId,
            method: 'PUT',
            data: inputData,
            success: function (data) {
                DisplayResult2("Add Cost", data);
            }
        });
    });

});