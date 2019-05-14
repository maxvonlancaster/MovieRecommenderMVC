import React, { Component } from 'react';

export default class MovieInput extends Component {
    constructor(props) {
        super(props);
        this.state = {
            MovieName: this.props.movieName || "",
            MovieGanre: this.props.movieName || "",
            genres: [],
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleChangeGanre = this.handleChangeGanre.bind(this);
        this.handleDropDownChange = this.handleDropDownChange.bind(this);
    }

    componentWillMount() {
        const genres = fetch("Movie/getGenres")
            .then(res => res.json())
            .then((result) => {this.setState({ genres: result, MovieGanre: result[0].genreName }) })
    }

    handleChange(e) {
        this.setState({ MovieName: e.target.value });
    }

    handleChangeGanre(e) {
        this.setState({ MovieGanre: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        
        const response = fetch("Movie/addMovie", {
            method: 'POST',
            headers: {
                'accept': 'application/json',
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                'movieId': 0,
                'movieName': this.state.MovieName,
                'movieGanre': this.state.MovieGanre
            })
        });

        this.setState({
            MovieName: "",
            MovieGanre: ""
        });

        window.location.reload();
    }

    setDropDownList() {
        return this.state.genres.map(function (genre) {
            return <option>{genre.genreName}</option>
        })
    }

    handleDropDownChange(e) {
        this.setState({ MovieGanre: e.target.value });
    }

    render() {
        return (
            <div className="row" id="contact">
                <div className="filter">
                    <form className="form" onSubmit={this.handleSubmit} id="formContact">
                        <label>Name</label>
                        <input id="formName" name="formName" value={this.state.MovieName} onChange={this.handleChange} required />
                        <label>Ganre</label>
                        <select id="formDropDownGanre" onChange={this.handleDropDownChange}>
                            {this.setDropDownList()}
                        </select>
                        <input type="submit" value="Submit" className="btn--cta" id="btn-submit" />
                    </form>
                </div>
            </div>
            )
    }
}