import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Rating from './Rating.jsx';
import Filter from './Filter';
import PopoverUpdateMovie from './PopoverUpdateMovie.jsx';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import reducer from '../store/reducer';
import { Button, Popover, PopoverHeader, PopoverBody } from 'reactstrap';
import { connect } from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';

class Grid extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            error: null,
            popoverOpen: false,
            genres: [],
            MovieGanre: "",
            pagingModel: {
                pageSize: 10,
                pageNumber: 1,
                sortBy: null,
                isDescending: null,
                searchBy: null,
                searchText: "",
                totalPages: null,
            },
        };

        this.toggle = this.toggle.bind(this);
        this.tableBody = this.tableBody.bind(this);
        this.tableHeaders = this.tableHeaders.bind(this);
    }

    //componentWillReceiveProps(nextProps) {
    //    this.setState({
    //        pagingModel: nextProps.store.getState()
    //    })
    //}

    componentDidMount() {
        //fetch("Movie/getAllMovies")
        //    .then(res => res.json())
        //    .then((result) => { this.setState({ data: result }) });
        //const xhr = new XMLHttpRequest();
        //let url = "api/GetAll";
        //xhr.open('GET', url, true);
        //console.log(xhr.statusText);
        //this.setState({ data: JSON.parse(xhr.responseText) })
        const genres = fetch("Movie/getGenres")
            .then(res => res.json())
            .then((result) => {this.setState({ genres: result, MovieGanre: result[0].genreName }) });

        const response = fetch("Movie/getPagedMovies", {
            method: 'POST',
            headers: {
                'accept': 'application/json',
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                'pageSize': this.state.pagingModel.pageSize,
                'pageNumber': this.state.pagingModel.pageNumber,
                'sortBy': this.state.pagingModel.sortBy,
                'isDescending': this.state.pagingModel.isDescending,
                'searchBy': this.state.pagingModel.searchBy,
                'searchText': this.state.pagingModel.searchText,
            })
        })
            .then(res => res.json())
            .then((result) => { this.setState({ data: result }) });
    }

    toggle() {
        this.setState({
            popoverOpen: !this.state.popoverOpen
        });
    }

    tableHeaders() {
        return(
        <thead>
        <tr>
                    <th className="action-column">MovieId</th>
                    <th>Name</th>
                    <th className="genre-column">Genre</th>
                    <th className="rating-column">Rating</th>
                    <th className="action-column">Update</th>
                    <th className="action-column">Delete</th>
        </tr>
    </thead>)
    }

    tableBody() {
        const data = this.state.data;

        return (
            data.map((row) => {
                const updateId = "button-update-" + row.movieId;
                return (<tr key={row.movieId} id={row.movieId}><td>{row.movieId}</td><td>{row.movieName}</td><td>{row.movieGanre}</td>
                    <td>
                        <Rating movieId={row.movieId} rating={row.rating} />
                    </td>
                    <td>
                        <PopoverUpdateMovie
                            target={updateId}
                            data={row}
                            genres={this.state.genres}
                            MovieGanre={this.state.MovieGanre} />
                    </td>
                    <td>
                        <a
                            className="glyphicon glyphicon-remove"
                            aria-hidden="true"
                            onClick={() => {deleteMovie(row.movieId)}}>
                        </a>
                    </td>
                </tr>)
            })
        )

        function updateMovie(id) { };

        function deleteMovie(id) {
            const response = fetch("Movie/deleteMovie", {
                method: 'POST',
                headers: {
                    'accept': 'application/json',
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    'movieId': id,
                    'movieName': null,
                    'movieGanre': null
                }),
            }).then(document.getElementById(id).remove());
        }
    }

    //deleteMovie(id) {
    //    const response = fetch("Movie/addMovie", {
    //        method: 'POST',
    //        headers: {
    //            'accept': 'application/json',
    //            'content-type': 'application/json'
    //        },
    //        body: JSON.stringify({
    //            'id': id
    //        })
    //    });

    //}

    //renderMovies() {
    //    const data = this.state.data;
    //    return data.map(item => {
    //        return <div>id = {item.movieId}, Name = {item.name}, Ganre = {item.ganre} </div>})
    //}

    render() {
        console.log(this.state);
        //const store = createStore(reducer);
        return (
            <div>
                <div>
                    <Provider store={this.props.store}><Filter pagingModel={this.state.pagingModel} /></Provider>
        </div>
            <div>
            <table className="table table-bordered table-hover table-movies table-striped">
                {this.tableHeaders()}
                <tbody>{this.tableBody()}</tbody>
            </table>
        </div></div>)
    }
}

const mapStateToProps = (state) => {
    console.log("mapState fired in GRID")
    return {
        pagingModel: state,
    }
}

export default connect(mapStateToProps, null)(Grid);