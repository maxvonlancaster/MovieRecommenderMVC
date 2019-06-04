import React from 'react';
import Grid from './components/Grid.jsx';
import MovieInput from './components/MovieInput.jsx';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import reducer from './store/reducer';
import { connect } from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import store from './store/index';


if (window.store === undefined) {
    window.store = store;
    console.log("New store");
}
//const store = createStore(reducer, composeWithDevTools());
var initModel = store.getState();
//const store = createStore(paggingReducer);

//store.dispatch({ type: 'Next' });



ReactDOM.render(
    <Grid store={window.store} pagingModel={initModel} />,
        document.getElementById("cont")
);

ReactDOM.render(
    <MovieInput />,
    document.getElementById("movieInput")
);

