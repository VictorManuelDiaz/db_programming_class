import React from 'react';
import moment from 'moment';
import SongsView from './songs.view';

const initialValues = {
    id: '',
    title: '',
    titleError: false,
    image: 'https://i.pinimg.com/originals/bf/de/e3/bfdee36b16c326b925b9825b79a24bfb.jpg',
    length_str: '',
    length_strError: false,
    artist: '',
    artistError: false,
    album: '',
    albumError: false
};

const API_URL = "http://localhost:5015/api/v1/";

const Songs = () => {
    const [values, setValues] = React.useState(initialValues);
    const [dialogType, setDialogType] = React.useState(1);
    const [songs, setSongs] = React.useState([]);

    const handleChange = name => event => {
        setValues({ ...values, [name]: event.target.value });
    };

    const sendRequest = async (method, route, body = null) => {
        const response = await fetch(route, {
            "method": method,
            "headers": {
                "content-type": "application/json",
                "accept": "application/json"
            },
            "body": body
        });
        const data = await response.json();
        return data;
    };

    const loadData = () => {
        const route = `${API_URL}role/get_all`;
        sendRequest("GET", route).then(data => {
            setSongs(data);
            console.log('roles', data)
        });
    }

    React.useEffect(() => {
        loadData();
    }, {loadData});

    const validate = () => {
        const {
            title,
            length_str,
            artist,
            album
        } = values;
        let titleError = false;
        let length_strError = false;
        let artistError = false;
        let albumError = false;

        if (title === '') titleError = true;
        else titleError = false;

        if (length_str === '') length_strError = true;
        else length_strError = false;

        if (artist === '') artistError = true;
        else artistError = false;

        if (album === '') albumError = true;
        else albumError = false;

        setValues({
            ...values,
            titleError,
            length_strError,
            artistError,
            albumError
        });

        if (!titleError && !length_strError && !artistError && !albumError) return false;
        else return true;
    }

    const resetForm = () => {
        loadData();
        setValues(initialValues);
    }

    const songAction = (type, song) => {
        setDialogType(type);
        setValues({...song, length_str: moment.utc(moment.duration(song.length).asMilliseconds()).format('mm:ss')});
    }

    const saveSong = () => {
        const error = validate();
        if (!error) {
            values.length_str = `00:${values.length_str}`;
            switch (dialogType) {
                case 1:
                    sendRequest("POST", `${API_URL}song`, JSON.stringify(values)).then(() => {
                        resetForm();
                    });
                    break;
                case 2:
                    sendRequest("PUT", `${API_URL}song/${values.song_id}`, JSON.stringify(values)).then(() => {
                        resetForm();
                    });
                    break;
                case 3:
                    sendRequest("DELETE", `${API_URL}song/${values.song_id}`).then(() => {
                        resetForm();
                    });
                    break;
                default:
                    break;
            }
        }
        else {
            console.log('Error');
        }
    }


    return (
        <SongsView
            title={values.title}
            titleError={values.titleError}
            length={values.length_str}
            lengthError={values.length_strError}
            artist={values.artist}
            artistError={values.artistError}
            album={values.album}
            albumError={values.albumError}
            rows={songs}
            handleChange={handleChange}
            saveSong={saveSong}
            songAction={songAction}
            dialogType={dialogType}
        />
    )
}

export default Songs;