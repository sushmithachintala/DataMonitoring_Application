import React, { Component, ChangeEvent } from 'react';
import { Redirect } from "react-router-dom";
type Props = {};
type State = ILoginData & {
    isUserValid: boolean,
    isSubmitted:boolean
};
export class Login extends Component {
    constructor(props: Props) {
        super(props);
        this.onChangeUsername = this.onChangeUsername.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);
        this.loginUser = this.loginUser.bind(this);       
        this.state = {
            username: "",
            password: "",
            isUserValid: false,
            isSubmitted: false
        };
    }
    onChangeUsername(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            username: e.target.value
        });
    }
    onChangePassword(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            password: e.target.value
        });
    }
    loginUser() {
        const data = {
            username: this.state.username,
            password: this.state.password
        };
        this.setState({
            isSubmitted: true
        })
        fetch('login/LoginUser?userName=' + data.username + '&password=' + data.password).then(response => response.json())
       .then((res) => {
           if (res) {
               this.setState({
                   isUserValid: true
               });
           }
        });
    }
    render() {
        const { isSubmitted, username, password, isUserValid } = this.state;
        let message = '';
        if (isUserValid) {
            return <Redirect to={'/fetch-data'}>
            </Redirect>
        }
        if (isSubmitted) {
            message = " Invalid Username or Password";
        }
        return (
            <div className="submit-form">
               <div>
                        <div className="form-group">
                            <label htmlFor="username">UserName</label>
                            <input
                                type="text"
                                className="form-control"
                                id="username"
                                required
                                value={username}
                                onChange={this.onChangeUsername}
                                name="username"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="password"
                                required
                                value={password}
                                onChange={this.onChangePassword}
                                name="password"
                            />
                        </div>
                        <button onClick={this.loginUser} className="btn btn-success">
                            Login
                            </button>
                            {message}
                    </div>              
            </div>
        );
    }
}