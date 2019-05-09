import React from 'react';
import Grid from './components/Grid.jsx';
import MovieInput from './components/MovieInput.jsx';
import ReactDOM from 'react-dom';

const elem = "cont";
console.log(elem);

    ReactDOM.render(
        <Grid />,
        document.getElementById(elem)
);

ReactDOM.render(
    <MovieInput />,
    document.getElementById("movieInput")
);

