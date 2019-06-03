import React from 'react';
import Grid from './components/Grid.jsx';
import MovieInput from './components/MovieInput.jsx';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import reducer from './store/reducer';
import { connect } from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';



const store = createStore(reducer, composeWithDevTools());
var initModel = store.getState();
//const store = createStore(paggingReducer);

//store.dispatch({ type: 'Next' });


ReactDOM.render(
    <Grid store={store} pagingModel={initModel} />,
        document.getElementById("cont")
);

ReactDOM.render(
    <MovieInput />,
    document.getElementById("movieInput")
);

