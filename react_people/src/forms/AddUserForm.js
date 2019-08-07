import React, { Component } from "react";

class AddUserForm extends Component {
  constructor(props) {
    super(props);

    this.initialState = {
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      cityId: '1'
    };

    this.state = this.initialState;
  }

  handleChange = event => {
    const { name, value } = event.target;

    this.setState({
      [name]: value,
    });
  };

  onFormSubmit = event => {
    event.preventDefault();
    if (!this.state.firstName || !this.state.lastName || !this.state.email || !this.state.phone)
      // message
      return

    this.props.addCharacter(this.state);
    this.setState(this.initialState);
  };

  render() {
    const { firstName, lastName, email, phone, cityId } = this.state;

    return (

      <form onSubmit={this.onFormSubmit}>
        <label>Firstname</label>
        <input
          type="text"
          name="firstName"
          value={firstName}
          onChange={this.handleChange}
        />
        <label>Lastname</label>
        <input
          type="text"
          name="lastName"
          value={lastName}
          onChange={this.handleChange}
        />
        <label>Email</label>
        <input
          type="text"
          name="email"
          value={email}
          onChange={this.handleChange}
        />
        <label>Phone (optional)</label>
        <input
          type="text"
          name="phone"
          value={phone}
          onChange={this.handleChange}
        />
        <label>City</label>
        {/* <input
          readOnly
          type="text"
          name="cityId"
          value={cityId}
          onChange={this.handleChange}
        /> */}
        <select name="cityId" onChange={this.handleChange}>
          <option value={cityId}>1 Stockholm</option>
          <option value="2">2 Gothenburg</option>
          <option value="3">3 Malmoe</option>
        </select>

        <button type="submit" className="btn btn-sm btn-primary m-1">Submit</button>

      </form >

    );
  }
}

export default AddUserForm;
