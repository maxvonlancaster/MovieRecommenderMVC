import React, { Component } from 'react';

export default class Rating extends Component {
    constructor(props) {
        super(props);
        this.state = {
            rating: this.props.rating || null,
            initRating: this.props.rating || null,
            temp_rating: null,
            movieId: this.props.movieId || null,
        }
        //this.rate = this.rate.bind(this);
        //this.star_over = this.star_over.bind(this);
        //this.star_out = this.star_out.bind(this);
    }

    rate(rating) {
        this.setState({
            rating: rating,
            temp_rating: rating
        });
        console.log(this.state);

        if (this.state.initRating === null) {
            const response = fetch("Rating/addRating", {
                method: 'POST',
                headers: {
                    'accept': 'application/json',
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    'movieId': this.state.movieId,
                    'rating': this.state.rating,
                })
            })
        }
        else {
            const response = fetch("Rating/updateRating", {
                method: 'POST',
                headers: {
                    'accept': 'application/json',
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    'movieId': this.state.movieId,
                    'rating': this.state.rating,
                })
            })
        }

        this.setState({
            initRating : rating,
        })
    }

    star_over(rating) {
        //this.state.temp_rating = this.state.rating;
        //this.state.rating = rating;

        this.setState({
            temp_rating: this.state.rating,
            rating: rating,
        });
    }

    star_out() {
        this.setState({ rating: this.state.temp_rating });
    }



    render() {
        var stars = [];

        for (var i = 0; i < 10; i++) {
            var klass = 'star-rating__star';

            if (this.state.rating >= i && this.state.rating != null) {
                klass += ' is-selected';
            }

            stars.push(
                <label
                    className={klass}
                    onClick={this.rate.bind(this,i) }
                    onMouseOver={this.star_over.bind(this,i) }
                    onMouseOut={this.star_out.bind(this) }>
                    ★
        </label>
            );
        }

        return (
            <div className="star-rating">
                {stars}
            </div>
        );
    }
}