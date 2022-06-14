$(document).ready(function () {
    loadData();
    $("#lengthInput").inputmask('Regex', {
        regex: "^[0-9]{2}:[0-5][0-9]$"
    });
});

function getFormattedDuration(length) {
    return moment.utc(moment.duration(length).asMilliseconds()).format('mm:ss')
}

function loadData() {
    let songs = sendRequest('GET', 'song');
    let rows = '';
    songs && songs.forEach((element, key) => {
        rows += `
            <tr>
                <th class="align-middle" scope="row"><span>${key + 1}</span></th>
                <th class="align-middle" scope="row">
                    <button class="btn action-btn"><i class="fa-solid fa-play"></i></button>
                </th>
                <td class="align-middle" scope="row">
                    <img
                        style="width: 45px; height: 45px; border-radius: 5px; margin-right: 10px"
                        src=${element.image}
                    >
                    <span>${element.title}</span>
                </td>
                <td class="align-middle" scope="row">${getFormattedDuration(element.length)}</td>
                <td class="align-middle" scope="row">${element.artist}</td>
                <td class="align-middle" scope="row">${element.album}</td>
                <td class="align-middle" scope="row">
                    <button
                        onclick="songAction(true, '${element.song_id}')"
                        class="btn action-btn me-2"
                    >
                        <i class="fa-solid fa-pen"></i>
                    </button>
                    <button
                        onclick="songAction(false, '${element.song_id}')"
                        class="btn action-btn"
                    >
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
    });
    $('tbody').append(rows);
}

let song_id;

function saveSong() {
    let data = {
        title: $("#titleInput").val(),
        image: 'https://i.pinimg.com/originals/bf/de/e3/bfdee36b16c326b925b9825b79a24bfb.jpg',
        length_str: `00:${$("#lengthInput").val()}`,
        artist: $("#artistInput").val(),
        album: $("#albumInput").val()
    }
    let button = $("#save-btn").text();
    let method = button == "Guardar" ? "POST" : (button == "Actualizar" ? "PUT" : "DELETE");
    let route = button == "Guardar" ? `song` : `song/${song_id}`;
    sendRequest(method, route, JSON.stringify(data));
    location.reload();
}

function songAction(isUpdate, song) {
    song_id = song;
    let selected_song = sendRequest("GET",`song/${song_id}`);

    $("#titleInput").val(selected_song.title).prop("disabled", !isUpdate);
    $("#lengthInput").val(getFormattedDuration(selected_song.length)).prop("disabled", !isUpdate);
    $("#artistInput").val(selected_song.artist).prop("disabled", !isUpdate);
    $("#albumInput").val(selected_song.album).prop("disabled", !isUpdate);

    $("#form-title").text(isUpdate ? 'Editar canción' : 'Eliminar canción');
    $("#save-btn").text(isUpdate ? 'Actualizar' : 'Eliminar');
    $("#save-btn").removeClass(isUpdate ? 'btn-danger' : 'btn-primary');
    $("#save-btn").addClass(isUpdate ? 'btn-primary' : 'btn-danger');
}

function sendRequest(method, route, data = {}) {
    return $.ajax({
        type: method,
        dataType: 'json',
        data: data,
        url: `http://localhost:53125/api/${route}`,
        global: false,
        async: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            return data
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('error: ', errorThrown);
        }
    }).responseJSON;
}

