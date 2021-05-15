# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.4] - 2021-5-15

- Fixed compile error introduced in 1.0.3 (PR #5)

## [1.0.3] - 2021-5-12

A couple of fixes and enhancements courtesy of JesseTG on github:
 - All properties now implement the IEquatable interface for better equality comparing (PR #3).
 - Renamed a private field for consistency. This shouldn't require any changes for end users (PR #2).

## [1.0.2] - 2020-7-14

 - Added support for map category and layout properties.
 - Backend refactoring to make the editor UI far more extensible.

## [1.0.1] - 2020-4-29

This release migrates the package settings to use the Unity Settings Manager system rather than a ScriptableObject in the assets folder.

## [1.0.0] - 2019-9-18

### This is the first release of *\<Rewired Inspector Properties\>*.

Initial release.
