import { createStore } from "redux";
import reducer from "./reducer.js";
import { composeWithDevTools } from 'redux-devtools-extension';

//var reducer = require('./reducer.js');
const store = createStore(reducer, composeWithDevTools());

export default store;