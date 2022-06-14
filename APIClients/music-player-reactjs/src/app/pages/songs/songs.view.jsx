import React from 'react';
import {
    TextField, Button, InputAdornment, Grid,
    Card, CardHeader, CardContent, Table,
    TableContainer, TableHead, TableRow, TableCell,
    Paper, TableBody, IconButton, Stack, Avatar
} from '@mui/material';
import SegmentIcon from '@mui/icons-material/Segment';
import PersonOutlineIcon from '@mui/icons-material/PersonOutline';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import AlbumIcon from '@mui/icons-material/Album';
import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import InputMask from 'react-input-mask';
import Theme from '../../components/theme/theme';
import moment from 'moment';

const SongsView = (props) => {
    const {
        title, titleError, length, lengthError,
        artist, artistError, album, albumError,
        rows, handleChange, saveSong, songAction,
        dialogType
    } = props;

    return (
        <Theme>
            <React.Fragment>
                <Card>
                    <CardHeader titleTypographyProps={{ sx: { color: 'rgb(0, 114, 229)' } }} title="Nueva canción" />
                    <CardContent>
                        <Grid container spacing={4}>
                            <Grid marginRight={6} item xs={12} sm={12} md={2} lg={2}>
                                <TextField
                                    id="title-field"
                                    variant="standard"
                                    focused
                                    label="Título"
                                    disabled={dialogType === 3 ? true : false}
                                    value={title}
                                    onChange={handleChange('title')}
                                    style={{ width: 230 }}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <SegmentIcon color='primary' />
                                            </InputAdornment>
                                        )
                                    }}
                                    error={titleError}
                                    helperText={titleError && "Campo obligatorio"}
                                />
                            </Grid>
                            <Grid marginRight={6} item xs={12} sm={12} md={2} lg={2}>
                                <InputMask
                                    mask="99:99"
                                    disabled={dialogType === 3 ? true : false}
                                    value={length}
                                    onChange={handleChange('length_str')}
                                >
                                    {() => <TextField
                                        id="length-field"
                                        variant="standard"
                                        focused
                                        disabled={dialogType === 3 ? true : false}
                                        label="Duración"
                                        style={{ width: 230 }}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <AccessTimeIcon color='primary' />
                                                </InputAdornment>
                                            )
                                        }}
                                        error={lengthError}
                                        helperText={lengthError && "Campo obligatorio"}
                                    />}
                                </InputMask>
                            </Grid>
                            <Grid marginRight={6} item xs={12} sm={12} md={2} lg={2}>
                                <TextField
                                    id="artist-field"
                                    variant="standard"
                                    focused
                                    label="Artista"
                                    disabled={dialogType === 3 ? true : false}
                                    value={artist}
                                    onChange={handleChange('artist')}
                                    style={{ width: 230 }}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <PersonOutlineIcon color='primary' />
                                            </InputAdornment>
                                        )
                                    }}
                                    error={artistError}
                                    helperText={artistError && "Campo obligatorio"}
                                />
                            </Grid>
                            <Grid marginRight={6} item xs={12} sm={12} md={2} lg={2}>
                                <TextField
                                    id="album-field"
                                    variant="standard"
                                    focused
                                    label="Album"
                                    disabled={dialogType === 3 ? true : false}
                                    value={album}
                                    onChange={handleChange('album')}
                                    style={{ width: 230 }}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <AlbumIcon color='primary' />
                                            </InputAdornment>
                                        )
                                    }}
                                    error={albumError}
                                    helperText={albumError && "Campo obligatorio"}
                                />
                            </Grid>
                            <Grid item xs={12} sm={12} md={2} lg={2}>
                                <Button onClick={saveSong} color={dialogType == 3 ? "error" : "primary"} variant="contained">
                                    {dialogType == 1 ? 'Guardar' : (dialogType == 2 ? 'Actualizar' : 'Eliminar')}
                                </Button>
                            </Grid>
                        </Grid>
                    </CardContent>
                </Card>
                <TableContainer sx={{ marginTop: 5 }} component={Paper}>
                    <Table sx={{ minWidth: 650 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell></TableCell>
                                <TableCell></TableCell>
                                <TableCell></TableCell>
                                <TableCell align="right"><b>Título</b></TableCell>
                                <TableCell align="right"><b>Duración</b></TableCell>
                                <TableCell align="right"><b>Artista</b></TableCell>
                                <TableCell align="right"><b>Album</b></TableCell>
                                <TableCell align="right"><b>Opciones</b></TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rows.map((row, key) => (
                                <TableRow
                                    key={row.song_id}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell component="th" scope="row">
                                        {key + 1}
                                    </TableCell>
                                    <TableCell align="right">
                                        <IconButton aria-label="play">
                                            <PlayArrowIcon color='primary' />
                                        </IconButton>
                                    </TableCell>
                                    <TableCell sx={{ display: 'flex', justifyContent: 'right' }}>
                                        <Avatar variant="rounded" src={row.image} />
                                    </TableCell>
                                    <TableCell align="right">
                                        {row.title}
                                    </TableCell>
                                    <TableCell align="right">
                                        {moment.utc(moment.duration(row.length).asMilliseconds()).format('mm:ss')}
                                    </TableCell>
                                    <TableCell align="right">
                                        {row.artist}
                                    </TableCell>
                                    <TableCell align="right">
                                        {row.album}
                                    </TableCell>
                                    <TableCell align="right">
                                        <Stack justifyContent="end" direction="row" spacing={1}>
                                            <IconButton onClick={() => songAction(2, row)} aria-label="update">
                                                <EditIcon color='primary' />
                                            </IconButton>
                                            <IconButton onClick={() => songAction(3, row)} aria-label="delete">
                                                <DeleteIcon color='error' />
                                            </IconButton>
                                        </Stack>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </React.Fragment>
        </Theme>
    );
}

export default SongsView;
