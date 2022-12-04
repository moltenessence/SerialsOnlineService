import { IGroupedGenres } from "../Common/Models/IGropedGenres";
import { connect } from 'react-redux';
import React, { useState, useEffect } from 'react';
import { Dispatch, bindActionCreators } from "redux";
import { RootState } from "../redux/store";
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import * as serialsActionCreators from '../redux/Serials/actionCreators'
import { getIsFetching, getGenres } from '../redux/Serials/selectors';
import Preloader from './other/Preloader';
import { GenreItem, GenreRaw, GenresWrapper } from "./styles/Genres.style";
import { getUser } from "../redux/User/selectors";
import { fetchUser } from "../redux/User/actionCreators";

function mapStateToProps(state: RootState) {
    return {
        isFetching: getIsFetching(state),
        genres: getGenres(state),
        user: getUser(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    fetchGenres: serialsActionCreators.fetchGenres,
    fetchUser: fetchUser
}, dispatch);

type GenressProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes

const Genres: React.FC<GenressProps> = ({ isFetching, genres, fetchGenres, user, fetchUser }) => {
    useEffect(() => {
        fetchUser();
        fetchGenres();
    }, [genres]);

    const content = genres?.map((record: IGroupedGenres) => {
        return (
            <GenreItem>
                <GenreRaw>Genre: {record.genre}</GenreRaw>
                <GenreRaw>Amount of serials: {record.amount}</GenreRaw>
            </GenreItem>);
    });

    return (
        <GenresWrapper>
            <h1>Genres</h1>
            {user ?
                <div>
                    {isFetching ? <Preloader /> : null}
                    {content ?? <p>No genres provided.</p>}
                </div>
                : <p>You need to login.</p>}
        </GenresWrapper>
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(Genres);