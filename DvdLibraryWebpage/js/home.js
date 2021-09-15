$(document).ready(function() {

    clearDvds();
    loadDvds();

});

function openAddForm() {
    $('#displayDvds').hide();

    $('#CreateErrorMessages')
        .empty()
        .attr({ class: '' });

    $('#createDvdDiv').show();
}

//stops the search form from refreshing the page
$("#searchForm").submit(function (e) {
    e.preventDefault();
});

function searchPressed() {
    searchType = getSearchType();
    searchInputValid = document.getElementById('searchTerm').reportValidity();
    if (!searchInputValid && searchType == null) {
        $('#errorMessages')
            .append($('<li>'))
            .attr({ class: 'list-group-item list-group-item-danger' })
            .text('Both Search Category and Search Term are required.');
        return false;
    }
    if (searchType == null) {
        $('#errorMessages')
            .append($('<li>'))
            .attr({ class: 'list-group-item list-group-item-danger' })
            .text('Please select a search category.');
    }
    else {
        clearErrorMessages();
        if (searchType == 'Title') {
            titleSearch();
        }
        else if (searchType == 'Director Name') {
            directorSearch();
        }
        else if (searchType == 'Rating') {
            ratingSearch();
        }
        else if (searchType == 'Release Year') {
            yearSearch();
        }
    }
    return false;
}

function clearErrorMessages() {
    $('#errorMessages').empty().attr({ class: ''});
}

function titleSearch() {
    search = getSearchInput();
    var rows = $('#dvdTableBody');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvds/title/' + search,
        success: function (dvdArray) {
            clearDvds();

            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.id;
                var row = '<tr>';
                row += '<td><a href="#" onclick="detailedView(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="openEditForm(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

                rows.append(row);
            });

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling title search function.');
        }
    })
}

function directorSearch() {
    search = getSearchInput();
    var rows = $('#dvdTableBody');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvds/director/' + search,
        success: function (dvdArray) {
            clearDvds();

            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.id;
                var row = '<tr>';
                row += '<td><a href="#" onclick="detailedView(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="openEditForm(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

                rows.append(row);
            });

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling director search function.');
        }
    })
}

function yearSearch() {
    search = getSearchInput();
    var rows = $('#dvdTableBody');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvds/year/' + search,
        success: function (dvdArray) {
            clearDvds();

            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.id;
                var row = '<tr>';
                row += '<td><a href="#" onclick="detailedView(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="openEditForm(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

                rows.append(row);
            });

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling year search function.');
        }
    })
}

function ratingSearch() {
    search = getSearchInput();
    var rows = $('#dvdTableBody');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvds/rating/' + search,
        success: function (dvdArray) {
            clearDvds();

            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.id;
                var row = '<tr>';
                row += '<td><a href="#" onclick="detailedView(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="openEditForm(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

                rows.append(row);
            });

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling rating search function.');
        }
    })
}

function getSearchType() {
    return $('#selectCategory').val();
}

function getSearchInput() {
    return $('#searchTerm').val();
}

function openEditForm(dvdId) {
    $('#displayDvds').hide();

    $('#EditErrorMessages')
        .empty()
        .attr({ class: '' })

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvd/' + dvdId,
        success: function (data, status) {
            $('#titleForEditForm').text('Edit Dvd: ' + data.title);
            $('#editDvdTitle').val(data.title);
            $('#editReleaseYear').val(data.releaseYear);
            $('#editDirector').val(data.director);
            $('#editRating').val(data.rating);
            $('#editNotes').val(data.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.');
        }
    })

    $('#editSaveButton').attr('onclick', 'checkEditFormValid(' + dvdId + ')');

    $('#editDvdDiv').show();
}

function checkEditFormValid(dvdId) {
    if (document.getElementById('editDvdForm').checkValidity()) {
        postEdit(dvdId);
    }
    if (!document.getElementById('editDvdTitle').reportValidity()) {
        $('#EditErrorMessages')
            .empty()
            .attr({ class: '' })
        $('#EditErrorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a title for the Dvd'));
    }
    else if (!document.getElementById('editReleaseYear').reportValidity()) {
        $('#EditErrorMessages')
            .empty()
            .attr({ class: '' })
        $('#EditErrorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a 4-digit year.'));
    }
}

function checkAddFormValid() {
    $('#CreateErrorMessages')
        .empty()
        .attr({ class: '' })
    if (document.getElementById('createDvdForm').checkValidity()) {
        addDvd();
    }
    if (!document.getElementById('createDvdTitle').reportValidity()) {
        $('#CreateErrorMessages')
            .empty()
            .attr({ class: '' })
        $('#CreateErrorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a title for the Dvd'));
    }
    else if (!document.getElementById('createReleaseYear').reportValidity()) {
        $('#CreateErrorMessages')
            .empty()
            .attr({ class: '' })
        $('#CreateErrorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a 4-digit year.'));
    }
}

function postEdit(dvdId) {
    $.ajax({
        type: 'PUT',
        url: 'http://localhost:61498/dvd/' + dvdId,
        data: JSON.stringify({
            dvdId: dvdId,
            title: $('#editDvdTitle').val(),
            releaseYear: $('#editReleaseYear').val(),
            director: $('#editDirector').val(),
            rating: $('#editRating').val(),
            notes: $('#editNotes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            $('#errorMessages').empty();
            $('#editDvdTitle').val('');
            $('#editReleaseYear').val('');
            $('#editDirector').val('');
            $('#editRating').val('');
            $('#editNotes').val('');
            backToDisplay();
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });

}

function addDvd() {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:61498/dvd',
        data: JSON.stringify({
            title: $('#createDvdTitle').val(),
            releaseYear: $('#createReleaseYear').val(),
            director: $('#createDirector').val(),
            rating: $('#createRating').val(),
            notes: $('#createNotes').val()
       }),
       headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
       },
        'dataType': 'json',
           success: function() {
               $('#errorMessages').empty();
               $('#createDvdTitle').val('');
               $('#createReleaseYear').val('');
               $('#createDirector').val('');
               $('#createRating').val('');
               $('#createNotes').val('');
               backToDisplay();
           },
           error: function () {
            $('#errorMessages')
             .append($('<li>')
             .attr({class: 'list-group-item list-group-item-danger'})
             .text('Error calling web service. Please try again later.')); 
        }
     })
}

function loadDvds() {
    clearDvds();

    $('#displayDvds').show();
    var rows = $('#dvdTableBody');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvds',
        success: function(dvdArray) {
            $.each(dvdArray, function(index, dvd){
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.id;
                var row = '<tr>';
                row += '<td><a href="#" onclick="detailedView(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="openEditForm(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

                rows.append(row);
            })
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>'))
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.');
        }
    })

}

function clearDvds() {
    $('#dvdTableBody').empty();
}

function detailedView(dvdId) {
    $('#displayDvds').hide();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:61498/dvd/' + dvdId,
        success: function(data, status) {
            $('#detailedViewTitle').text(data.title);
            $('#detailedYear').text(data.releaseYear);
            $('#detailedDirector').text(data.director);
            $('#detailedRating').text(data.rating);
            $('#detailedNotes').text(data.notes);

        },
        error: function() {
            $('#errorMessages')
                .append($('<li>'))
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.');
        }
    })

    $('#detailedDvdView').show();
}

function deleteDvd(dvdId) {
    var userselection = confirm("Are you sure you want to delete this movie?");

    if (userselection == false) {
        backToDisplay();
        return;
    }

    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:61498/dvd/' + dvdId,
        success: function() {
            loadDvds();
        }
    });
}

function backToDisplay() {
    $('#detailedDvdView').hide();

    $('#detailedViewTitle').text('');
    $('#detailedYear').text('');
    $('#detailedDirector').text('');
    $('#detailedRating').text('');
    $('#detailedNotes').text('');

    $('#editDvdDiv').hide();
    $('#createDvdDiv').hide();

    loadDvds();
}