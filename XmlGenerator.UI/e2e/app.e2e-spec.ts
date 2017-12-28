import { XmlgeneratorPage } from './app.po';

describe('xmlgenerator App', function() {
  let page: XmlgeneratorPage;

  beforeEach(() => {
    page = new XmlgeneratorPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
